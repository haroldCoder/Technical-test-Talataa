import React from 'react'

export default function Search() {
    const [searchTerm, setSearchTerm] = React.useState('');

    const handleSearch = (event) => {
      const value = event.target.value;
      setSearchTerm(value);
      onSearch(value);
    };
  
    return (
      <div className="search-bar">
        <input
          type="text"
          placeholder="Buscar por Nombre o Apellido"
          value={searchTerm}
          onChange={handleSearch}
        />
      </div>
    );
}
