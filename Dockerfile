# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/mssql/server
CMD docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=1StrongPassword!' -p 1433:1433 — name mssql1 -d mcr.microsoft.com/mssql/server