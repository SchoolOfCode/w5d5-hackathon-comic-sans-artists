CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    FullName TEXT,
    Day INTEGER, 
    Month TEXT,
    StarSign TEXT
);

INSERT INTO Users (
    FullName, Day, Month, StarSign
) VALUES ('Michael Sheen', 5, 'February', 'Aquarius'),('Cristiano Ronaldo', 5, 'February', 'Aquarius'), ('Ioan Dumitru Chirescu', 5, 'February', 'Aquarius'),('Laura Linney', 5, 'February', 'Aquarius'),('Mary Louise Cleave', 5, 'February', 'Aquarius'), ('Daffy Duck', 17, 'April', 'Aries'), ('Sean Bean', 17, 'April', 'Aries'), ('Victoria Beckham', 17, 'April', 'Aries'), ('Olivia Hussey', 17, 'April', 'Aries'), ('Frederick I of Sweden', 17, 'April', 'Aries'), ('Pope Evaristus', 17, 'April', 'Aries');