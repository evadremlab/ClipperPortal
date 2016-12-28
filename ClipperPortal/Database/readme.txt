FOR DEPLOYMENT:
1) Run "scripts.txt" dbscript to create tables and populate static data.
2) Delete the devicesurvey table before importing ClipperDBExport.csv (using MySql Workbench).
3) Run "runAfterImport.txt" dbscript to alter the devicesurvey table and create primary key/index.