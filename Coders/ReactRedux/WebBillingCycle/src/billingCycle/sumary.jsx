import React from 'react'

import Grid from '../common/layout/grid'
import Row from '../common/layout/row'
import ValueBox from '../common/widget/valueBox'

const Sumary = ({ creditos, debitos }) => (
  <Grid cols="12">
    <Row>
      <ValueBox cols="12 4" cor="green" corTexto="white" label="Créditos" valor={`R$ ${creditos}`} />
      <ValueBox cols="12 4" cor="red" corTexto="white" label="Débitos" valor={`R$ ${debitos}`} />
      <ValueBox cols="12 4" cor="blue" corTexto="white" label="Consolidado" valor={`R$ ${creditos- debitos}`} />
    </Row>
  </Grid>
)

Sumary.defaultProps = {
  creditos: 0,
  debitos: 0
}

export default Sumary
