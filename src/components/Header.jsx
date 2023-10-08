import React from 'react'
import coder from '../assets/coder.png'

export const Header = () => {
  return (
    <div className='header p-4'>
        <h1>Employee Talataa</h1>
        <img src={coder} alt='coder' />
    </div>
  )
}
