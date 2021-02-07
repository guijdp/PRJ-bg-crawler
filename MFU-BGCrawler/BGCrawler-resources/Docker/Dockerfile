FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA='Y'
ENV SA_PASSWORD='P@55word'

WORKDIR app/

COPY Resources .

ENTRYPOINT ["/bin/bash", "./startup.sh"]