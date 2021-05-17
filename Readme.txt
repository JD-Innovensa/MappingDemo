1. This uses sqlite - if you perform a migration it might not be applied to the debug database, might need to delete it
2. Logging added to db context for convenience of seeing sql statements
3. Initial migration done with -o Data\Migrations for code organisation