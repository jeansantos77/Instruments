USE dbFinancialInstruments;
GO

-- Verifica se a procedure existe
IF OBJECT_ID('CategorizeFinancialInstruments', 'P') IS NOT NULL
BEGIN
    -- Se existir, dropa a procedure
    DROP PROCEDURE CategorizeFinancialInstruments;
END;
GO

CREATE PROCEDURE CategorizeFinancialInstruments
AS
BEGIN
    -- Declara��o de vari�veis
    DECLARE @InstrumentID INT;
    DECLARE @MarketValue DECIMAL(18, 2);
    DECLARE @TypeInstrument VARCHAR(50);

	CREATE TABLE #TempIDs (Id INT);
	
    -- Declara��o do Cursor que vai ler todos os Financial Instruments que ainda n�o foram processados
    DECLARE InstrumentCursor CURSOR FOR
        SELECT Id, MarketValue, TypeInstrument 
		FROM FinancialInstruments 
		WHERE DateProcessed IS NULL;

    -- Abertura do Cursor
    OPEN InstrumentCursor;

    -- Inicializa��o do Fetch
    FETCH NEXT FROM InstrumentCursor INTO @InstrumentID, @MarketValue, @TypeInstrument;

    -- Loop atrav�s dos registros
    WHILE @@FETCH_STATUS = 0
    BEGIN
	    -- Armazena os ID's que est�o sendo lidos para depois mostrar o resultado final
	    INSERT INTO #TempIDs (Id) VALUES (@InstrumentID);

		DECLARE @FindType INT;
		DECLARE @NameCategory VARCHAR(50) = NULL;

		-- Verifica se existe no banco de dados esse Type
	    SELECT @FindType = 1 from TypeInstruments WHERE [Name] = @TypeInstrument;

		-- Se n�o houver registros, salva a categoria como NOT FOUND para mostrar para o usu�rio que falta essa inser��o no banco de dados
		IF @FindType = 0
		BEGIN
			SET @NameCategory = @TypeInstrument + ' not found!';
		END
		ELSE
		BEGIN
		   -- Verifica se a categoria � Medium
		   SELECT @NameCategory = [Name] FROM Categories WHERE StartValue <= @MarketValue AND EndValue >= @MarketValue;

		   IF @NameCategory IS NULL
		   BEGIN
		      -- Se n�o for, verifica se � Low 
			  SELECT TOP 1 @NameCategory = [Name] FROM Categories WHERE StartValue > @MarketValue AND EndValue = 0;
		   END

		   IF @NameCategory IS NULL
		   BEGIN
		      -- Sen�o verifica se � High
			  SELECT TOP 1 @NameCategory = [Name] FROM Categories WHERE StartValue < @MarketValue AND EndValue = 0 ORDER BY StartValue DESC;
		   END
		END

		-- Atualiza a tabela com a categoria encontrada e salva a data do processamento
		UPDATE FinancialInstruments
		SET CategoryName = @NameCategory,
		    DateProcessed = GETDATE()
		WHERE Id = @InstrumentID

        FETCH NEXT FROM InstrumentCursor INTO @InstrumentID, @MarketValue, @TypeInstrument;
    END

    CLOSE InstrumentCursor;
    DEALLOCATE InstrumentCursor;

    -- Exibi��o as categorias
    SELECT CategoryName 
	FROM FinancialInstruments
	WHERE Id IN (SELECT Id FROM #TempIDs);

	-- Drop da tabela tempor�ria ap�s uso
    DROP TABLE #TempIDs;
END;