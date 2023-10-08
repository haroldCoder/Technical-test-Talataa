import axios from 'axios';
import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react'
import Card from './Card';
import Search from './Search';

function Home() {
    const [employees, setEmployees] = useState([]); // estado de los employees, sera un arreglo

    // poner useEffect para que constantemente haga peticiones al servidor
    useEffect(()=>{
        const getData = async() =>{
            const res = await axios.get(import.meta.env.VITE_API_EMPLOYEE);
            //la respuesta va aa ser el valor de los employees
            setEmployees(res.data);
        }
        //llamar la funcion para que traiga todos los datos.
        //getData()
    }, []);

  return (
    <div className='home'>
        <section className='search'>
            <Search setEmployees={setEmployees} />
        </section>
        <section>
           {
                employees.map((e)=>( //hacer un mapeo de los employees para ver la informacion completa
                    <Card nombre={e.nombre} apellidos={e.apellidos} documento={e.documento} email={e.email} dirección={e.dirección} teléfono={e.teléfono} género={e.género} />
                ))
            } 
        </section>
    </div>
  )
}

export default Home