docker build -t lweys_apii -f Dockerfile.LWEYSAPI ../LWEYSWebAPI
docker-compose -f docker-compose.yml down
docker-compose build
docker-compose -f docker-compose.yml up -d
docker system prune -a -f