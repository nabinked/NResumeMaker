FROM microsoft/aspnet

EXPOSE 5000  
ENTRYPOINT ["dnx", "-p", "project.json", "web"]

COPY project.json /wwwroot/  
WORKDIR /wwwroot  
RUN ["dnu", "restore"]  
COPY . /wwwroot  