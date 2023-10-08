import React from 'react'

export default function Card({nombre, documento, email, dirección, teléfono, género, apellidos}) {
  return (
    <div className="card">
      <div className="card-content">
        <h2 className="card-title">{nombre} {apellidos}</h2>
        <p className="card-description">{documento}</p>
        <p className="card-description">{email}</p>
        <p className="card-description">{dirección}</p>
        <p className="card-description">{teléfono}</p>
        <p className="card-description">{género}</p>
      </div>
    </div>
  )
}
