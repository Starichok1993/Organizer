@echo off

echo Start create database from scratch:

echo Start create database
mysql -u "root" --password="asd123!1" -e "DROP DATABASE IF EXISTS organizer_db;"
mysql -u "root" --password="asd123!1" -e "CREATE DATABASE organizer_db;"
echo End create database

echo Start create tables 
mysql -u "root" --password="asd123!1" "organizer_db" < "schema.sql"
echo End create tables 

echo Start fill initial data
mysql -u "root" --password="asd123!1" "organizer_db" < "ref_data.sql"
echo End fill initial data 

echo End creating database from scratch

echo Execute update scripts 
cd updates
for %%f in (*.*) do mysql -u "root" --password="asd123!1" "organizer_db" < "%%f"
cd ..
echo End execute update scripts


echo Start fill test data
mysql --default-character-set=utf8 -u "root" --password="asd123!1" "organizer_db" < "test_data.sql"
echo End fill test data

pause