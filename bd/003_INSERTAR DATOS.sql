GO
USE DB_CARRITO


go


insert into USUARIO(Nombres,Apellidos,Correo,Contrasena,EsAdministrador) values ('testnombre','testapellido','admin@cibertec.com','admin',1)

GO
insert into CATEGORIA(Descripcion) values
('Accion'),
('Estrategia'),
('Simulacion'),
('Aventura'),
('Terror'),
('Conduccion'),
('Lucha'),
('Rol/RPG')
GO

insert into MARCA(Descripcion) values
('REMEDY ENTERTAIMENT'),
('2K GAMES'),
('THQ NORDIC'),
('UBISOFT'),
('FOCUS HOME INT'),
('CAPCOM CO LTD'),
('SQUARE ENIX'),
('WARNER BROS GAMES'),
('AMAZON GAMES'),
('ZAUM'),
('CURVE DIGITAL'),
('KRAFTON INC'),
('505 GAMES'),
('FRICTIONAL GAMES'),
('OBSIDIAN ENTERTAIMENT'),
('XBOX GAME STUDIOS'),
('LUDEON STUDIOS'),
('11 BIT STUDIOS'),
('ELECTRONIC ARTS'),
('SCS SOFTWARE'),
('GHOST GAMES'),
('CRITERION GAMES'),
('MOON STUDIOS'),
('TEAM CHERRY')


GO


insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Alans Wake Remastered',
'En este galardonado thriller de acci�n cinem�tica, el afligido escritor Alan Wake se embarca en la desesperada b�squeda de su mujer
desaparecida, Alice. Alan Wake Remastered ofrece la experiencia completa, que incluye el juego principal y las dos expansiones de la
historia (La se�al y El escritor) con nuevos e impresionantes gr�ficos en 4K.',
1,5,'58.99','40','~/Imagenes/Productos/1.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Mafia Definitive Edition','Redise�ado desde cero. 
Asciende en la jerarqu�a de la mafia durante la �poca de la Ley Seca y el crimen organizado en EE. UU. Tras un inesperado percance con la
mafia, el taxista Tommy Angelo entra a rega�adientes en el mundo del crimen organizado. A pesar de su reticencia inicial, las ventajas de
unirse a la familia Salieri son demasiadas como para ignorarlas.',
2,1,'135','110','~/Imagenes/Productos/2.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('BIOMUTANT�','BIOMUTANT� es un RPG de kung-fu desarrollado en un mundo abierto posapocal�ptico
que cuenta con un sistema de combate que combina artes marciales con ataques cuerpo a cuerpo, disparos y habilidades mutantes.
Una plaga asola el mundo y el �rbol de la Vida irradia muerte desde sus ra�ces. Las tribus est�n divididas. Explora un mundo ca�tico y escribe su destino: �ser�s su salvador o lo sumir�s en la oscuridad?',
3,4,'149.95','50','~/Imagenes/Productos/3.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Monster Jam Steel Titans 2','Monster Jam Steel Titans 2 ofrece m�s camiones favoritos de los fans dentro de los nuevos mundos de Monster Jam.
Nuevos modos multijugador online, 38 camiones para elegir y cinco nuevos mundos exteriores. Los pilotos entrenan en Camp Crushmore y compiten en estadios reales para convertirse en el campe�n definitivo.
�M�s camiones! El plantel ofrece 38 de los mejores camiones en la historia de Monster Jam como Higher Education, Sparkle Smash y Grave Digger.',
3,6,'74.95','100','~/Imagenes/Productos/4.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Far Cry� 6','Te damos la bienvenida a Yara, un para�so tropical que se ha detenido en el tiempo. El dictador de Yara, Ant�n Castillo, est� decidido a devolver a su naci�n la antigua gloria perdida por cualquier medio, y su hijo Diego sigue sus sangrientos pasos. La opresi�n a la que someten a su pueblo ha dado pie a una revoluci�n.',
4,4,'199.99','90','~/Imagenes/Productos/5.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Darksiders Genesis','En DARKSIDERS GENESIS conocer�s el mundo de DARKSIDERS anterior a los acontecimientos del juego original. Adem�s, cuenta con un cuarto y �ltimo jinete, LUCHA, y con un modo cooperativo por primera vez en la historia de la saga.'
,3,8,'73.95','60','~/Imagenes/Productos/6.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('NBA 2K21','NBA 2K21 es la nueva entrega de la famosa serie de baloncesto superventas NBA 2K. Gracias a las importantes mejoras realizadas en la jugabilidad, los gr�ficos, las funciones en l�nea comunitarias y competitivas, y con una gran variedad de modos de juego, NBA 2K21 ofrece una experiencia �nica llena de baloncesto y cultura de la NBA, donde "este juego lo es todo".',
2,3,'199.90','90','~/Imagenes/Productos/7.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Farming Simulator 19','�La simulaci�n agr�cola definitiva vuelve con una completa revisi�n gr�fica y la experiencia agr�cola m�s completa de la historia! Convi�rtete en un moderno agricultor y desarrolla una granja en dos enormes entornos de Am�rica y Europa repletos de emocionantes actividades agr�colas nuevas, cultivos que cosechar y animales que cuidar.',
5,3,'54','200','~/Imagenes/Productos/8.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Resident Evil Village','Experience survival horror like never before in the eighth major installment in the storied Resident Evil franchise - Resident Evil Village.
Set a few years after the horrifying events in the critically acclaimed Resident Evil 7 biohazard, the all-new storyline begins with Ethan Winters and his wife Mia living peacefully in a new location, free from their past nightmares. Just as they are building their new life together, tragedy befalls them once again.',
6,5,'200','99','~/Imagenes/Productos/9.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Marvel''s Guardians of the Galaxy','Tu reci�n formado grupo de legendarios proscritos deber� salvar el universo en esta nueva pero fiel versi�n de los Guardianes de la Galaxia. Sin querer, desencadenas una serie de catastr�ficos eventos y te ver�s en la obligaci�n de surcar alucinantes mundos habitados por personajes emblem�ticos y nuevos de Marvel. Pon a todo trapo la cinta de �xitos ochenteros y prep�rate para darlo todo.',
7,4,'199','20','~/Imagenes/Productos/10.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Mortal Kombat 11','�La experiencia MK11 definitiva! Juega como los protectores de la Tierra en 2 aclamadas historias donde el tiempo se distorsiona en una lucha para impedir que Kronika regrese el tiempo y reinicie la historia. Con el reparto completo de 37 luchadores, incluyendo a Rain, Mileena y Rambo.
Incluye MK11, el Paquete de Kombate 1, la expansi�n Aftermath y el Paquete de Kombate 2.',
8,7,'120','50','~/Imagenes/Productos/11.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Street Fighter V','Experience the intensity of head-to-head battle with Street Fighter� V! Choose from 16 iconic characters, each with their own personal story and unique training challenges, then battle against friends online or offline with a robust variety of match options.
Earn Fight Money in Ranked Matches, play for fun in Casual Matches or invite friends into a Battle Lounge and see who comes out on top! PlayStation 4 and Steam players can also play against each other thanks to cross-play compatibility!',
6,7,'65','300','~/Imagenes/Productos/12.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('New World','Explora un electrizante videojuego MMO de mundo abierto. Tras un naufragio, llegar�s a las costas de la sobrenatural isla de Aeternum, donde vivir�s peligros y oportunidades, y te forjar�s un nuevo destino. Gozar�s de infinitas oportunidades para la lucha, la caza y la forja en medio de la naturaleza y ruinas de la isla. Canaliza fuerzas sobrenaturales o blande armas mortales en un sistema de combate sin clases y en tiempo real. Entra a la batalla solo, con un peque�o equipo o como miembro de un enorme ej�rcito en las batallas JcE y JcJ. La decisi�n es tuya.',
9,8,'69','500','~/Imagenes/Productos/13.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Disco Elysium - The Final Cut','Disco Elysium - The Final Cut is the definitive edition of the groundbreaking role playing game. You�re a detective with a unique skill system at your disposal and a whole city block to carve your path across. Interrogate unforgettable characters, crack murders, or take bribes. Become a hero or an absolute disaster of a human being.',
10,8,'95','110','~/Imagenes/Productos/14.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('The Ascent Deluxe Edition','The Ascent es un Shooter de Rol y Acci�n ambientado en un futuro Cyberpunk. El juego se juega desde una perspectiva isom�trica. Sobrevive en una gran metr�polis futurista dirigida por una corporaci�n nefasta y habitada por criaturas de toda la galaxia. El jugador se pondr� en los zapatos de un trabajador de esta empresa la cual un d�a cierra por motivos desconocidos y la supervivencia del distrito est� en riesgo. toma las armas y emprende una misi�n para averiguar qu� provoc� todo. Personaliza a tu personaje con ciberpartes para cada estilo de juego. Asigna puntos de habilidad al subir de nivel y prueba pr�tesis para vencer al enemigo de diferentes formas. Haz aliados y enemigos y encuentra botines al explorar la arcolog�a y su gran variedad de distritos, desde los barrios marginales hasta el lujo de la alta sociedad.',
11,8,'84','38','~/Imagenes/Productos/15.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Back 4 Blood','Back 4 Blood es un emocionante juego de disparos en primera persona cooperativo, de los creadores de la aclamada franquicia de Left 4 Dead. Te encuentras en el centro de una guerra contra los infectados. Estos seres, que alguna vez fueron humanos, son hu�spedes de un par�sito letal que los convierte en criaturas determinadas a devorar lo que queda de la civilizaci�n. Con la inminente extinci�n de la humanidad, depende de ti y tus amigos llevar la lucha al enemigo, erradicar a los infectados y recuperar el mundo.',
8,1,'179.99','2000','~/Imagenes/Productos/16.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('PUBG: BATTLEGROUNDS','PUBG: BATTLEGROUNDS is a battle royale shooter that pits 100 players against each other in a struggle for survival. Gather supplies and outwit your opponents to become the last person standing.
PUBG: BATTLEGROUNDS, aka Brendan Greene, is a pioneer of the battle royale genre and the creator of the battle royale game modes in the ARMA series and H1Z1: King of the Kill. At PUBG Corp., Greene is working with a veteran team of developers to make PUBG into the world''s premiere battle royale experience.',
12,1,'52','999','~/Imagenes/Productos/17.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Ghostrunner','Ghostrunner es un juego intenso de acci�n vertiginosa con perspectiva en primera persona y ambientado en una megaestructura ciberpunk. Sube por la torre Dharma, el �ltimo refugio de la humanidad tras un cataclismo devastador. Tendr�s que llegar a la cima y enfrentarte a la ama de las llaves, una tirana, para vengarte de una vez por todas.',
13,1,'99.90','155','~/Imagenes/Productos/18.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('SOMA','SOMA is a sci-fi horror game from Frictional Games, the creators of Amnesia: The Dark Descent. It is an unsettling story about identity, consciousness, and what it means to be human.
The radio is dead, food is running out, and the machines have started to think they are people. Underwater facility PATHOS-II has suffered an intolerable isolation and we�re going to have to make some tough decisions. What can be done? What makes sense? What is left to fight for?',
14,5,'73.95','300','~/Imagenes/Productos/19.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Amnesia: The Dark Descent','Amnesia: The Dark Descent, a first person survival horror. A game about immersion, discovery and living through a nightmare. An experience that will chill you to the core.',
14,5,'49.95','34','~/Imagenes/Productos/20.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('The Outer Worlds','The Outer Worlds es un videojuego de acci�n y rol en un inmenso mundo abierto de ciencia ficci�n que te llevara a vivir una experiencia JDR �nica. En el juego te despiertas de tu hibernaci�n en una nave colona que se ha perdido mientras se dirig�a a Halcyon, la colonia m�s lejana de la Tierra, en los limites de la galaxia, solo para encontrarte en medio de una conspiraci�n que amenaza con destruir la nave. A medida que exploras los confines del espacio y te encuentras con diversas formas de vida, todas con ansias de poder, la personalidad que decidas adoptar determinar� c�mo se desarrolla esta historia basada en tu personaje.',
15,4,'199','90','~/Imagenes/Productos/21.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Age of Empires IV','Uno de los juegos de estrategia en tiempo real m�s queridos vuelve a la gloria con Age of Empires IV, en el que quedar�s al centro de las �picas batallas hist�ricas que dieron forma al mundo. Age of Empires IV, que cuenta con nuevas maneras, unas familiares y otras innovadoras, de expandir tu imperio en vastos paisajes con una impresionante fidelidad visual 4K, trae un juego de estrategia en tiempo real evolucionado a una nueva generaci�n.
Volver a la historia - El pasado es pr�logo pues te sumergir�s en un vasto entorno hist�rico de 8 civilizaciones diversas de todo el mundo, desde los ingleses y los chinos hasta el Sultanato de Delhi, en tu b�squeda de la victoria. Construye ciudades, gestiona recursos y lidera tus tropas a la batalla en tierra y en el mar en 4 campa�as distintas con 35 misiones que abarcan 500 a�os de historia desde la Edad Oscura hasta el Renacimiento.',
16,2,'102','210','~/Imagenes/Productos/22.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('RimWorld','RimWorld es un simulador de colonias (Construir y gestionar tu propia colonia espacial) enfatizado en la ciencia ficci�n y dirigido por una inteligencia artificial. El juego establece al jugador en el papel de gestor de una colonia en un planeta del borde gal�ctico, donde los colonos deben sobrevivir a diversos eventos generados aleatoriamente por la inteligencia artificial. No controlaremos directamente a los colonos, excepto en situaciones de combate, solo ordenaremos la creaci�n de estructuras, o la realizaci�n de diversas acciones, que los colonos, o �peones� realizan cuando consideren adecuado (influenciado por las circunstancias del pe�n, sus habilidades, o los tipos de trabajos que tenga asignados.) Para asegurar la supervivencia de la colonia, deberemos administrar y equilibrar las diversas condiciones que garantizan el bienestar f�sico y mental de sus colonos, asegur�ndonos de que est�n bien alimentados, tengan un hogar c�modo y ropa adecuada para el clima.',
17,2,'61','110','~/Imagenes/Productos/23.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Frostpunk','Frostpunk es un videojuego que mezcla varios generos como la construcci�n de ciudades, la estrategia y la supervivencia, adem�s de ser el nuevo t�tulo de los creadores de This War of Mine. El objetivo del juego es mantener la supervivencia de una sociedad que cuestiona la idea de hasta qu� punto son capaces de llegar las personas cuando se ven que est�n al borde de la extinci�n en un mundo totalmente fri� y congelado. Debido a estas extremas condiciones la humanidad crea una tecnolog�a basada en el vapor para hacer frente al fr�o extremo. El dirigente de la ciudad tiene que gestionar tanto la situaci�n particular de los habitantes como la infraestructura que garantiza su supervivencia.',
18,2,'53','999','~/Imagenes/Productos/24.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Forza Horizon 4','Forza Horizon 4 es un videojuego de conducci�n y carreras de mundo abierto. El juego se ambienta en Reino Unido abarcando 4 estaciones que cambian el ambiente del juego, tambi�n la climatolog�a, y la naturaleza. M�s de 450 autom�viles para conducir y 5 eventos de exhibici�n.',
16,6,'102','500','~/Imagenes/Productos/25.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('The Sims� 4','Da rienda suelta a la imaginaci�n y crea un mundo de Sims �nico. Explora y personaliza cada detalle de las casas de tus Sims y mucho m�s. Escoge c�mo se ven, act�an y visten tus Sims. Determina c�mo viven cada d�a. Construye y dise�a casas incre�bles para cada familia, luego dec�ralas con tus muebles y adornos favoritos. Visita distintos vecindarios donde podr�s conocer a otros Sims y aprender m�s sobre sus vidas. Descubre lugares hermosos con entornos caracter�sticos y vive aventuras espont�neas. Gestiona los altibajos de las vidas de tus Sims y descubre qu� ocurre cuando reproduces escenarios realistas o imaginarios. Cuenta tus historias mientras desarrollas relaciones, persigues profesiones y aspiraciones en la vida y te embarcas en un juego extraordinario con infinitas posibilidades.',
19,3,'139','15','~/Imagenes/Productos/26.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Euro Truck Simulator 2','Travel across Europe as king of the road, a trucker who delivers important cargo across impressive distances! With dozens of cities to explore from the UK, Belgium, Germany, Italy, the Netherlands, Poland, and many more, your endurance, skill and speed will all be pushed to their limits. If you�ve got what it takes to be part of an elite trucking force, get behind the wheel and prove it!',
20,3,'54.95','80','~/Imagenes/Productos/27.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Need for Speed� Most Wanted','Travel across Europe as king of the road, a trucker who delivers important cargo across impressive distances! With dozens of cities to explore from the UK, Belgium, Germany, Italy, the Netherlands, Poland, and many more, your endurance, skill and speed will all be pushed to their limits. If you�ve got what it takes to be part of an elite trucking force, get behind the wheel and prove it!',
22,3,'54.95','80','~/Imagenes/Productos/28.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Need for Speed� Payback','Need for Speed� Payback - Deluxe Edition te da ventaja. Destaca entre la multitud con art�culos de personalizaci�n exclusivos y recibe descuentos en el juego, bonus de REP y cinco cargamentos para empezar tu aventura. ',
21,6,'99','80','~/Imagenes/Productos/29.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Ori and the Will of the Wisps','Sum�rgete en una nueva aventura a trav�s de un gran y ex�tico mundo en el que encontrar�s imponentes enemigos y desafiantes acertijos a lo largo de tu aventura mientras revelas el destino de Ori.',
23,4,'17','100','~/Imagenes/Productos/30.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Hollow Knight','Hollow Knight es un juego de acci�n y aventura cl�sica en 2D ambientada en un vasto mundo interconectado. Explora cavernas tortuosas, ciudades antiguas y mortales p�ramos. Combate contra criaturas corrompidas, hazte amigo de extra�os insectos y resuelve los antiguos misterios en el coraz�n del reino. Acci�n cl�sica de desplazamiento lateral, con todos los avances modernos, Explora un vasto mundo interconectado de caminos olvidados, salvaje vegetaci�n y ciudades en ruinas, Equipa amuletos! Antiguas reliquias que proporcionan extra�os poderes y habilidades. �Elige las que prefieras y emprende un viaje �nico, M�s de 130 enemigos, 30 jefes �picos! Enfr�ntate a bestias feroces y vence a caballeros antiguos durante tu b�squeda a trav�s del reino. �Rastrea hasta el �ltimo enemigo y a��delo a tu Diario de cazador, Los bellos paisajes coloreados con una extravagante paralaje consiguen que este mundo transmita una sensaci�n de profundidad.',
24,4,'17','100','~/Imagenes/Productos/31.jpg')
go
