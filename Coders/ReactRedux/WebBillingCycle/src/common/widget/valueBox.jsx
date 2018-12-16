import React from 'react';
import PropTypes from 'prop-types';

import Grid from '../layout/grid';

const ValueBox = (props) => (
  <Grid cols={props.cols}>
    <div className={`card-panel ${props.cor}`}>
      <h3 className={`center-align ${props.corTexto}-text`}>{props.valor}</h3>
      <h6 className="center-align">{props.label}</h6>
    </div>
  </Grid>
);

ValueBox.propTypes = {
  cols: PropTypes.string,
  corText: PropTypes.string,
  valor: PropTypes.string,
  label: PropTypes.string
};

export default ValueBox;
