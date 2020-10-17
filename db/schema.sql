-- business partner db schema 
ALTER DATABASE CHARACTER SET utf8 COLLATE utf8_general_ci;

DROP PROCEDURE IF EXISTS AddColumnUnlessExists;
delimiter //

create procedure AddColumnUnlessExists(
	IN dbName tinytext,
	IN tableName tinytext,
	IN fieldName tinytext,
	IN fieldDef text)
begin
	IF NOT EXISTS (
		SELECT * FROM information_schema.COLUMNS
		WHERE column_name=fieldName
		and table_name=tableName
		and table_schema=dbName
		)
	THEN
		set @ddl=CONCAT('ALTER TABLE ',dbName,'.',tableName,
			' ADD COLUMN ',fieldName,' ',fieldDef);
		prepare stmt from @ddl;
		execute stmt;
	ELSE
		select CONCAT('COLUMN: ', fieldName, ' is already exists') AS output;
	END IF;
end//

delimiter ;

DROP PROCEDURE IF EXISTS DropForeignKeyIfExists;
DELIMITER $$
CREATE PROCEDURE DropForeignKeyIfExists(
	IN dbName tinytext,
	IN tableName VARCHAR(64), 
	IN constraintName VARCHAR(64))
BEGIN
    IF EXISTS(
        SELECT * FROM information_schema.table_constraints
        WHERE 
            table_schema    = dbName     AND
            table_name      = tableName      AND
            constraint_name = constraintName AND
            constraint_type = 'FOREIGN KEY')
    THEN
        SET @query = CONCAT('ALTER TABLE ', tableName, ' DROP FOREIGN KEY ', constraintName, ';');
        PREPARE stmt FROM @query; 
        EXECUTE stmt; 
        DEALLOCATE PREPARE stmt; 
    END IF; 
END$$
DELIMITER ;


DROP PROCEDURE IF EXISTS AddForeignKeyUnlessExists;
DELIMITER $$
CREATE PROCEDURE AddForeignKeyUnlessExists(
	IN dbName tinytext,
	IN foreignKeyTableName VARCHAR(64), 
	IN primaryKeyTableName VARCHAR(64), 
	IN foreignKeyFieldName VARCHAR(64), 
	IN primaryKeyFieldName VARCHAR(64), 
	IN constraintName VARCHAR(64))
BEGIN
	DECLARE idx VARCHAR(256);
    
    IF NOT EXISTS(
        SELECT * FROM information_schema.table_constraints
        WHERE 
            table_schema    = dbName					AND
            table_name      = foreignKeyTableName		AND
            constraint_name = constraintName			AND
            constraint_type = 'FOREIGN KEY')
    THEN
		SET idx = CONCAT(constraintName, '_idx');
		SET @query = CONCAT('ALTER TABLE ', foreignKeyTableName, ' ADD INDEX ', idx, ' ( ', foreignKeyFieldName , ' ASC);');PREPARE stmt FROM @query; 
        EXECUTE stmt; 
        DEALLOCATE PREPARE stmt; 

		SET @query = CONCAT('ALTER TABLE ', foreignKeyTableName, ' ADD CONSTRAINT ', constraintName, ' FOREIGN KEY ( ', foreignKeyFieldName, ') REFERENCES ', primaryKeyTableName, '(' , primaryKeyFieldName , ');');
		PREPARE stmt FROM @query; 
        EXECUTE stmt; 
	ELSE
		select CONCAT('FOREIGN KEY: ', constraintName, ' is already exists') AS output;
    END IF; 
END$$
DELIMITER ;

-- Table db_version
CREATE TABLE db_version (
  Id int(11) unsigned NOT NULL,
  Version VARCHAR(32) NOT NULL,
  Description VARCHAR(1024) NOT NULL,
  DateApplied DATETIME NOT NULL,
  PRIMARY KEY (Id)
 );


 CREATE TABLE to_do (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Description text NOT NULL,
  IsDone bit(1) NOT NULL DEFAULT 0,
  PRIMARY KEY(Id)
 ) AUTO_INCREMENT=1; 