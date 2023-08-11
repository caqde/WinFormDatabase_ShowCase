DECLARE @MyCursor CURSOR;
DECLARE @tableName varchar(max);
BEGIN
    SET @MyCursor = CURSOR FOR
    select TABLE_Name from INFORMATION_SCHEMA.TABLES where TABLE_NAME not in ('__MigrationHistory', '__EFMigrationsHistory');

    -- Drop constraints
    OPEN @MyCursor 
    FETCH NEXT FROM @MyCursor 
    INTO @tableName

    WHILE @@FETCH_STATUS = 0
    BEGIN
      EXEC ('ALTER TABLE ' + @tableName + ' NOCHECK CONSTRAINT ALL');

      FETCH NEXT FROM @MyCursor 
      INTO @tableName 
    END; 

    CLOSE @MyCursor ;

    -- empty tables
    OPEN @MyCursor 
    FETCH NEXT FROM @MyCursor 
    INTO @tableName

    WHILE @@FETCH_STATUS = 0
    BEGIN
      EXEC ('DELETE from ' + @tableName);

      FETCH NEXT FROM @MyCursor 
      INTO @tableName 
    END; 

    CLOSE @MyCursor ;

    -- Activate constraints
    OPEN @MyCursor 
    FETCH NEXT FROM @MyCursor 
    INTO @tableName

    WHILE @@FETCH_STATUS = 0
    BEGIN
      EXEC ('ALTER TABLE ' + @tableName + ' CHECK CONSTRAINT ALL');

      FETCH NEXT FROM @MyCursor 
      INTO @tableName 
    END; 

    CLOSE @MyCursor ;
    DEALLOCATE @MyCursor;
END;
