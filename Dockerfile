FROM microsoft/aspnet


COPY . /app
WORKDIR /app

EXPOSE 5000  
ENTRYPOINT ["dnx", "-p", "src/ResumeMaker/project.json", "web"] 
   
RUN ["dnu", "restore"]  

