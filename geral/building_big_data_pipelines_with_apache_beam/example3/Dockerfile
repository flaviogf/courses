FROM maven:3.9.2 AS build
WORKDIR /var/app
ADD pom.xml .
RUN mvn dependency:resolve
ADD . .
RUN mvn clean package

FROM openjdk:11.0.11-jre-slim
WORKDIR /var/app
COPY --from=build /var/app/target/dependency/*.jar ./lib/
COPY --from=build /var/app/target/beam-example3-1.0.0.jar .
ENTRYPOINT ["java", "-cp", "beam-example3-1.0.0.jar:lib/*"]
