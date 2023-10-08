import React from 'react'

export default function InsertUser() {
    const [employee, setEmployee] = React.useState({
        documento: '',
        nombre: '',
        apellidos: '',
        telefono: '',
        email: '',
        direccion: '',
        genero: '',
      }); //estado para guardar todos los datos
    
      const handleChange = (e) => {
        const { name, value } = e.target;
        setEmployee({
          ...employee,
          [name]: value,
        }); //guardar el value en el name asignado
      };
    
      const handleSubmit = (e) => {
        e.preventDefault();
        
        console.log(employee);
      };
    
      return (
        <div className="employee-form-container">
          <h2>Formulario de Empleado</h2>
          <form onSubmit={handleSubmit}>
            <div className="form-group">
              <label htmlFor="documento">Documento:</label>
              <input
                type="number"
                id="documento"
                name="documento"
                value={employee.documento}
                onChange={handleChange}
                placeholder='Documento'
                required
              />
            </div>
            <div className="form-group">
              <label htmlFor="nombre">Nombre:</label>
              <input
                type="text"
                id="nombre"
                name="nombre"
                value={employee.nombre}
                onChange={handleChange}
                required
                placeholder='Nombre'
              />
            </div>
            <div className="form-group">
              <label htmlFor="apellidos">Apellidos:</label>
              <input
                type="text"
                id="apellidos"
                name="apellidos"
                value={employee.apellidos}
                onChange={handleChange}
                required
                placeholder='Apellidos'
              />
            </div>
            <div className="form-group">
              <label htmlFor="telefono">Teléfono:</label>
              <input
                type="text"
                id="telefono"
                name="telefono"
                value={employee.telefono}
                onChange={handleChange}
                required
                placeholder='Telefono'
              />
            </div>
            <div className="form-group">
              <label htmlFor="email">E-Mail:</label>
              <input
                type="text"
                id="email"
                name="email"
                value={employee.email}
                onChange={handleChange}
                required
                placeholder='Email'
              />
            </div>
            <div className="form-group">
              <label htmlFor="direccion">Dirección:</label>
              <input
                type="text"
                id="direccion"
                name="direccion"
                value={employee.direccion}
                onChange={handleChange}
                required
                placeholder='Direccion'
              />
            </div>
            <div className="form-group">
              <label htmlFor="genero">Género:</label>
              <input
                type="text"
                id="genero"
                name="genero"
                value={employee.genero}
                onChange={handleChange}
                required
                placeholder='Genero'
              />
            </div>
            <button type="submit">Guardar</button>
          </form>
        </div>
      );
}
