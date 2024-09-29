create table authors (
    id uuid primary key,
    firstname varchar(100),
    lastname varchar(100),
    dateofbirth date,
    biography text,
    createdat date
);

create table categories (
    id uuid primary key,
    name varchar(255) unique,
    createdat date
);

create table books (
    id uuid primary key,
    title varchar(255) not null,
    description text,
    isbn varchar(13) unique,
    publisheddate date,
    authorid uuid,
    categoryid uuid,
    createdat date,
    foreign key (authorid) references authors(id),
    foreign key (categoryid) references categories(id)
);

create table users (
    id uuid primary key,
    username varchar(255) unique,
    email varchar(255) unique,
    passwordhash varchar(255),
    createdat date
);	

create table bookrentals (
    id uuid primary key,
    bookid uuid,
    userid uuid,
    rentaldate date,
    returndate date,
    createdat date,
    foreign key (bookid) references books(id),
    foreign key (userid) references users(id)
);