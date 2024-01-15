docker pull dependencytrack/bundled
docker volume create --name dependency-track-generic-importer
docker run -d -m 8192m -p 8081:8080 --name dependency-track-generic-importer -v dependency-track-generic-importer:/data dependencytrack/bundled