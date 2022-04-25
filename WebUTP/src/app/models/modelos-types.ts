export enum TablaMetodosAlumno {
    //metodos page principal   
    GET_CONSULTAR_GRID = "api/Alumno/listar",
    GET_REGISTRAR_ALUMNO = "api/Alumno/registrar",
    GET_REGISTRAR_USUARIO = "api/Alumno/registrarUsuario",
    GET_ALUMNO ="api/Alumno/obtenerAlumno",
}

export enum TablaMetodosEscuela {
    //metodos page principal   
    GET_CONSULTAR_LISTA = "api/Escuela/listar",
 
}

export enum TablaMetodosSemestre {
    //metodos page principal   
    GET_CONSULTAR_LISTA = "api/Semestre/listar",
    GET_CONSULTAR_LISTA_ALUMNO = "api/Semestre/listarSemestreAlumno",
}

export enum TablaMetodosCliclo {
    //metodos page principal   
    GET_CONSULTAR_LISTA = "api/Ciclo/listar",
 
}

export enum TablaMetodosCurso {
    //metodos page principal   
    GET_CONSULTAR_GRID = "api/Curso/listar",
    GET_CONSULTAR_ALUMNO_GRID = "api/Curso/listarCursosAlumno",
    
}

export enum TablaMetodosNotas {
    //metodos page principal   
    GET_REGISTRAR_NOTA = "api/Nota/registrar",
 
}


export enum TablaMetodosUsuario {
    //metodos page principal   
    GET_USURIO = "api/Usuario/consultarUsuario",
 
}

export enum TablaMetodosLogin {
    //metodos page principal   
    GET_AUTENTICACION = "api/identidad/login",
 
}