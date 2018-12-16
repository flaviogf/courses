import React from 'react';

export default (props) => (
  <div className={`input-field col ${props.col}`}>
    <input {...props.input} type={props.type} id={props.id} readOnly={props.readOnly} />
    <label htmlFor={props.id}>{props.label}</label>
  </div>
);
