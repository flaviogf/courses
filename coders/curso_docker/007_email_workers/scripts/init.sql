create database email_sender;

\c email_sender;

create table emails (
    id serial,
    data timestamp not null default current_timestamp,
    assunto varchar(100) not null,
    mensagem varchar(100) not null
);
