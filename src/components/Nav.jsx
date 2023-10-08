import React from 'react'
import {Link} from 'react-router-dom'

function Nav() {
  return (
    <div className='nav'>
        <Link to="/"><h2>Home</h2></Link>
        <Link to="/insertar_empleado"><h2>Add new user</h2></Link>
        <Link><h2>support creator</h2></Link>
    </div>
  )
}

export default Nav