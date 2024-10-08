FROM rabbitmq:management-alpine
ARG RABBITMQ_USER=ecommerce
ARG RABBITMQ_PASSWORD=Abcd@1234

ENV RABBITMQ_USER=${RABBITMQ_USER}
ENV RABBITMQ_PASSWORD=${RABBITMQ_PASSWORD}
ENV RABBITMQ_PID_FILE=/var/lib/rabbitmq/mnesia/rabbitmq

COPY ["rabbitmq/init.sh", "/init.sh"]

RUN ["chmod", "+x", "/init.sh"]

EXPOSE 15672

# Define default command
RUN ["apk", "add", "--no-cache", "--upgrade", "bash"]
CMD ["bash", "/init.sh"]