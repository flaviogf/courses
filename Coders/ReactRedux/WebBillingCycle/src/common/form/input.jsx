import React from 'react'

export default (props) => (
  <input
    placeholder={props.placeholder}
    readOnly={props.readOnly}
    type={props.type}
    {...props.input}
  />
)
