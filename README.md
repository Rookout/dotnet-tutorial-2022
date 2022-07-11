# Dotnet Containerized Application Sample

This application is an example application for the Rookout Dotnet Agent [tutorial](https://docs.rookout.com/docs/dotnet-container-tutorial/).

Run it in a few simple steps:
1. Build the container using Docker - `docker build . -t rookout-dotnet-todo`.
2. Run the built container using `docker run -it -p 8080:80 rookout-dotnet-todo`
3. Check out your brand new web app at `http://localhost:8080`.
4. You may also test your container with TODO backend [project](https://todobackend.com/) by going to `https://www.todobackend.com/specs/index.html?http://localhost:8080/todos`.
