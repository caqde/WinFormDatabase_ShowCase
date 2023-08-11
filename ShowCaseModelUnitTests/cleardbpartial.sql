DO $$

DECLARE MyCursor CURSOR FOR select TABLE_Name from INFORMATION_SCHEMA.TABLES where TABLE_NAME in (###TABLES###);
        tableName text;
BEGIN

    -- Drop constraints
    OPEN MyCursor;
    FETCH NEXT FROM MyCursor 
    INTO tableName;

    WHILE FOUND LOOP
      EXECUTE ('ALTER TABLE ' + tableName + ' NOCHECK CONSTRAINT ALL');

      FETCH NEXT FROM MyCursor 
      INTO tableName; 
    END LOOP; 

    CLOSE MyCursor;

    -- empty tables
    OPEN MyCursor; 
    FETCH NEXT FROM MyCursor 
    INTO tableName;

    WHILE FOUND LOOP
      EXECUTE ('DELETE from ' + tableName);

      FETCH NEXT FROM MyCursor 
      INTO tableName; 
    END LOOP; 

    CLOSE MyCursor ;

    -- Activate constraints
    OPEN MyCursor; 
    FETCH NEXT FROM MyCursor 
    INTO tableName;

    WHILE FOUND LOOP
      EXECUTE ('ALTER TABLE ' + tableName + ' CHECK CONSTRAINT ALL');

      FETCH NEXT FROM MyCursor 
      INTO tableName; 
    END LOOP; 

    CLOSE MyCursor ;
END;
$$;