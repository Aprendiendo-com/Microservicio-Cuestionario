using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservicio_Cuestionario.AccessData.Migrations
{
    public partial class CreateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuestionarios",
                columns: table => new
                {
                    CuestionarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    ClaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuestionarios", x => x.CuestionarioID);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    PreguntaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    CuestionarioId = table.Column<int>(nullable: false),
                    CalificacionParcial = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.PreguntaId);
                    table.ForeignKey(
                        name: "FK_Preguntas_Cuestionarios_CuestionarioId",
                        column: x => x.CuestionarioId,
                        principalTable: "Cuestionarios",
                        principalColumn: "CuestionarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    RegistroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudianteId = table.Column<int>(nullable: false),
                    CuestionarioId = table.Column<int>(nullable: false),
                    Calificacion = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.RegistroId);
                    table.ForeignKey(
                        name: "FK_Registros_Cuestionarios_CuestionarioId",
                        column: x => x.CuestionarioId,
                        principalTable: "Cuestionarios",
                        principalColumn: "CuestionarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    RespuestaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    PreguntaId = table.Column<int>(nullable: false),
                    Flag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.RespuestaId);
                    table.ForeignKey(
                        name: "FK_Respuestas_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "PreguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cuestionarios",
                columns: new[] { "CuestionarioID", "ClaseId", "Descripcion" },
                values: new object[,]
                {
                    { 1, 1, "Cuestionario de POO" },
                    { 2, 2, "Cuestionario de Manejo de excepciones" },
                    { 3, 3, "Cuestionario de Grafos" },
                    { 4, 4, "Cuestionario de verbo to be" },
                    { 5, 5, "Cuestionario de Presente Simple" },
                    { 6, 6, "Completa las sentencias usando Presente Continuo" },
                    { 7, 7, "Cuestionario de Campo eléctrico" },
                    { 8, 8, "Cuestinario de Campo Magnético" },
                    { 9, 9, "Cuestionario de Ecuaciones de Maxwell" }
                });

            migrationBuilder.InsertData(
                table: "Preguntas",
                columns: new[] { "PreguntaId", "CalificacionParcial", "CuestionarioId", "Descripcion" },
                values: new object[,]
                {
                    { 1, 0.0, 1, "¿Que es la Encapsulación?" },
                    { 26, 0.0, 9, "¿A qué se conoce como ecuaciones de Maxwell?." },
                    { 25, 0.0, 8, "El vacío, ¿Tiene Coercitividad?" },
                    { 24, 0.0, 8, "¿Qué es la Remanencia?" },
                    { 23, 0.0, 8, "¿Qué es la Coercitividad?" },
                    { 22, 0.0, 7, "¿Qué es un electroimán?" },
                    { 21, 0.0, 7, "¿Qué es un solenoide?" },
                    { 20, 0.0, 7, "El campo eléctrico es:" },
                    { 19, 0.0, 6, "Complete: I _______ (watch) TV right now." },
                    { 18, 0.0, 6, "Complete: You _______ (make) a great effort." },
                    { 17, 0.0, 6, "Complete: She _________ (leave) tomorrow morning." },
                    { 16, 0.0, 5, "Complete: Who _____ (be) your favourite football player? " },
                    { 15, 0.0, 5, "Complete: Paul _______ (sleep) seven hours a day." },
                    { 14, 0.0, 5, "Complete: She ______ (wash) her car every week? " },
                    { 13, 0.0, 4, "Complete: I ____ not ready." },
                    { 12, 0.0, 4, "Complete: _______ the books on the shelf?" },
                    { 11, 0.0, 4, "Complete: ___________ in the office?" },
                    { 10, 0.0, 3, "¿Cuál es el algoritmo que resuelve el problema del camino mínimo?" },
                    { 9, 0.0, 3, "Indique la definición correcta de Grafo." },
                    { 8, 0.0, 3, "Según la definición de Grafos, indice cual opción define mejor el concepto de trayectoria de un vértice v0 a vn." },
                    { 7, 0.0, 2, "¿Qué se puede hacer con la sentencia trow?" },
                    { 6, 0.0, 2, "¿Qué se define dentro del finally?" },
                    { 5, 0.0, 2, "Un programador, ¿puede disparar sus propias excepciones?" },
                    { 4, 0.0, 2, "¿Qué es una excepción?" },
                    { 3, 0.0, 1, "¿Que es Sobrecarga?" },
                    { 2, 0.0, 1, "¿Que son las Interfaces?" },
                    { 27, 0.0, 9, "¿Cuál de los siguientes parámetros no interviene en las ecuaciones de Maxwell?" },
                    { 28, 0.0, 9, "¿Qué sucede con el valor del Flujo si duplicamos el valor de la carga?" }
                });

            migrationBuilder.InsertData(
                table: "Respuestas",
                columns: new[] { "RespuestaId", "Descripcion", "Flag", "PreguntaId" },
                values: new object[,]
                {
                    { 1, "Es la capacidad que tienen los objetos de comportarse de múltiples formas recurriendo a la herencia.", false, 1 },
                    { 61, "Es un concepto de poca utilidad en electrostática.", false, 21 },
                    { 60, "Es un campo vectorial y sus unidades son newtons/coulombs.", true, 20 },
                    { 59, "Se define como la fuerza por unidad de carga en un punto dado.", false, 20 },
                    { 58, "Es una cantidad escalar muy fácil de calcular.", false, 20 },
                    { 57, "am watching", true, 19 },
                    { 56, "are watching", false, 19 },
                    { 55, "do watching", false, 19 },
                    { 54, "is make", false, 18 },
                    { 53, "is making", true, 18 },
                    { 52, "are making", false, 18 },
                    { 51, "leaved", false, 17 },
                    { 50, "is leaving", true, 17 },
                    { 49, "leaving", false, 17 },
                    { 48, "is", true, 16 },
                    { 47, "are", false, 16 },
                    { 46, "am", false, 16 },
                    { 45, "sleepes", false, 15 },
                    { 62, "Es un conjunto de espiras conectadas eléctricamente, a la manera de un resorte comprimido.", true, 21 },
                    { 44, "sleeps", true, 15 },
                    { 63, "Es un “anillo” conductor por el que circula la corriente eléctrica.", false, 21 },
                    { 65, "Es un campo físico que se representa por medio de un modelo que describe la interacción entre cuerpos.", false, 22 },
                    { 82, "Se anula.", false, 28 },
                    { 81, "El campo eléctrico.", false, 27 },
                    { 80, "El campo magnético.", false, 27 },
                    { 79, "El campo gravitatorio.", true, 27 },
                    { 78, "Al conjunto de ecuaciones que describen todos los fenómenos magnéticos.", false, 26 },
                    { 77, "Al conjunto fundamental de ecuaciones que describen todos los fenómenos electromagnéticos.", true, 26 },
                    { 76, "Al conjunto de ecuaciones que describen todos los fenómenos eléctricos.", false, 26 },
                    { 75, "A veces.", false, 25 },
                    { 74, "No.", true, 25 },
                    { 73, "Sí", false, 25 },
                    { 72, "Es el valor de la temperatura en el que la sustancia pierde su propiedad Ferromagnética.", false, 24 },
                    { 71, "Es el tiempo que dura magnetizada una sustancia.", true, 24 },
                    { 70, "Cuestinario de Campo Magnético.", false, 24 },
                    { 69, "Es la facilidad con que un material inducido, adquiere las propiedades del material inductor. En definitiva es la facilidad que tiene una sustancia de magnetizarse.", true, 23 },
                    { 68, "Es el equivalente de la resistencia en los circuitos magnéticos.", false, 23 },
                    { 67, "Es el equivalente de la resistencia en los circuitos eléctricos.", false, 23 },
                    { 66, "Es un imán no permanente cuya acción dura mientras se produce el pasaje de la corriente por el solenoide.", true, 22 },
                    { 64, "Es una línea de campo eléctrico siempre paralela a la superficies. ", false, 22 },
                    { 43, "sleep", false, 15 },
                    { 42, "washs", false, 14 },
                    { 41, "washes", true, 14 },
                    { 18, "Se puede utilizar para señalar un código y no lanzar una excepción si este tiene problemas.", false, 7 },
                    { 17, "Se puede utilizar para disparar una excepción.", true, 7 },
                    { 16, "Se puede identificar un error al cual posteriormente aplicar una excepción.", false, 7 },
                    { 15, "El código que captura y maneja el código que se lance la excepción.", false, 6 },
                    { 14, "El código que se ejecutará haya o no excepciones.", true, 6 },
                    { 13, "El código que se ejecuta cuando haya excepciones.", false, 6 },
                    { 12, "Sí.", true, 5 },
                    { 11, "No.", false, 5 },
                    { 10, "Es un evento que ocurre durante la ejecución de un programa y que interrumpe el flujo normal de operación.", true, 4 },
                    { 9, "Es un evento que ocurre durante la ejecución de un programa y que provoca que los ciclos no puedan terminarse.", false, 4 },
                    { 8, "Consiste en tener dos o más métodos con el mismo nombre pero diferentes parámetros.", true, 3 },
                    { 7, "Consiste en tener dos o más métodos con distinto nombre pero los mismos parámetros.", false, 3 },
                    { 6, "Es la base de la reutilización del código, obteniendo la información de sus superclases.", false, 2 },
                    { 5, "Es la capacidad que tienen los objetos de comportarse de múltiples formas recurriendo a la herencia.", false, 2 },
                    { 4, "Las interfaces definen lo que una clase que la implemente debe hacer.", true, 2 },
                    { 3, "Es un evento que ocurre durante la ejecucion del programa, interrumpiendo el flujo normal.", false, 1 },
                    { 2, "Es la forma de proteger u ocultar las propiedades de un objetos, estableciendo los permisos y niveles de visibilidad.", true, 1 },
                    { 19, "Un camino consecutivo de aristas consecutivas desde v0 hasta vn.", false, 8 },
                    { 20, "Es un camino de nodos alternantes desde v0 hasta vn.", false, 8 },
                    { 21, "Es una sucesión de longitud n, alternante de n+1 vértices y n aristas que comienza en v0 y termina en vn.", true, 8 },
                    { 22, "Es un conjunto de n-1 nodos alternantes y consecutivos desde v0 hasta vn.", false, 8 },
                    { 40, "washies", false, 14 },
                    { 39, "are", false, 13 },
                    { 38, "where", false, 13 },
                    { 37, "is not", false, 13 },
                    { 36, "am", true, 13 },
                    { 35, "Was", false, 12 },
                    { 34, "Are", true, 12 },
                    { 33, "Isn't", false, 12 },
                    { 83, "Se duplica.", true, 28 },
                    { 32, "Where is", false, 11 },
                    { 30, "When is", true, 11 },
                    { 29, "El algoritmo de Gauss.", false, 10 },
                    { 28, "El algoritmo de Dijkstra.", true, 10 },
                    { 27, "El algoritmo de VanVourer.", false, 10 },
                    { 26, "Múltiples nodos denominados vértices y caminos denominados marcos.", false, 9 },
                    { 25, "Un gráfico matemático que se emplea para modelar problemas de la vida real.", false, 9 },
                    { 24, "Un diagrama compuesto de nodos y conexiones.", false, 9 },
                    { 23, "Un conjunto de vértices y aristas, tal que cada arista está asociada a un par.", true, 9 },
                    { 31, "Who is", false, 11 },
                    { 84, "Se reduce a la mitad.", false, 28 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_CuestionarioId",
                table: "Preguntas",
                column: "CuestionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_CuestionarioId",
                table: "Registros",
                column: "CuestionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_PreguntaId",
                table: "Respuestas",
                column: "PreguntaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "Cuestionarios");
        }
    }
}
