import React from 'react';

import Row from '../layout/row';

export default (props) => (
  <form className="col s12 formulario" onSubmit={props.onSubmit}>
    {props.children}
  </form>
);
