FROM microsoft/aspnet

EXPOSE 5000  
ENTRYPOINT ["dnx", "-p", "project.json", "web"]

COPY /src/ResumeMaker/project.json /src/ResumeMaker/wwwroot/  
WORKDIR /src/ResumeMaker/wwwroot  
RUN dnu wrap C:/Users/nabin/OneDrive/MyRepositories/ResumeMaker/src/DbPortal/DbPortal.csproj
RUN ["dnu", "restore"]  
COPY . src/ResumeMaker/wwwroot  