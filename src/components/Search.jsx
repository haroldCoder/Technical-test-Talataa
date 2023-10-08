import axios from 'axios';
import React from 'react'

export default function Search({setEmployees}) {
    const [searchTerm, setSearchTerm] = React.useState('');

    const handleSearch = (event) => {
      const value = event.target.value;
      setSearchTerm(value);
    };

    const submitFilter = async() =>{
        let res = (await axios.get(`${import.meta.env.VITE_API_EMPLOYEE}?bysearch=${searchTerm}`)).data;
        res = res.sort((a, b)=>{
            const A = a.nombre.toLowerCase();
            const B = b.nombre.toLowerCase();
            return A.localeCompare(B);
        })
        setEmployees(res);
    }
  
    return (
      <div className="search-bar">
        <input
          type="text"
          placeholder="Buscar por Nombre o Apellido"
          value={searchTerm}
          onChange={handleSearch}
        />
        <button onClick={submitFilter}>Search</button>
      </div>
    );
}
