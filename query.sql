CREATE TABLE categoria(
	idcategoria int IDENTITY(1,1),
	categoria varchar(50),
	imagenCat varchar(150),
	PRIMARY KEY (idcategoria)
);

CREATE TABLE juego(
	idjuego int IDENTITY(1,1),
	nomJuego varchar(75),
	precio float, 
	existencias int,
	imagen varchar(150),
	idcategoria int,
	PRIMARY KEY (idjuego),
	FOREIGN KEY (idcategoria) REFERENCES categoria(idcategoria)
);