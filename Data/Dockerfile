FROM mcr.microsoft.com/mssql/server:2022-latest

ENV ACCEPT_EULA=Y
ENV MSSQL_PID=Express
ENV SA_PASSWORD=StrongP@ssword123

COPY . .
CMD [ "/opt/mssql/bin/sqlservr" ]
