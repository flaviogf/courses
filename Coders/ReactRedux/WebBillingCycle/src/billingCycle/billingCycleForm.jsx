import React from 'react';

import { connect } from 'react-redux';

import { bindActionCreators } from 'redux';

import { Field, reduxForm, formValueSelector } from 'redux-form';

import Form from '../common/form/form';
import LabelAndInput from '../common/form/labelAndInput';
import Grid from '../common/layout/grid';
import Row from '../common/layout/row';
import ItemList from './itemList'
import Sumary from './sumary'

import { init } from './billingCyclesActions';

class BillingCycleForm extends React.Component {

  componentDidMount() {
    Materialize.updateTextFields();
  }

  calculateSumary() {
    const sum = (t, v) => t + v
    const { creditos, debitos } = this.props
    if (creditos.length && debitos.length) {
      return {
        creditos: this.props.creditos.map((c) => +c.valor || 0).reduce(sum),
        debitos: this.props.debitos.map((d) => +d.valor || 0).reduce(sum)
      }
    }
  }

  render() {
    const { creditos, debitos } = this.calculateSumary()
    return (
      <Form onSubmit={this.props.handleSubmit}>
        <Row>
          <Field component={LabelAndInput} label="Nome" type="text" name="nome" id="nome" col="s12 m4" readOnly={this.props.readOnly} />
          <Field component={LabelAndInput} label="Mês" type="number" name="mes" id="mes" col="s12 m4" readOnly={this.props.readOnly} />
          <Field component={LabelAndInput} label="Ano" type="number" name="ano" id="ano" col="s12 m4" readOnly={this.props.readOnly} />
          <Sumary creditos={creditos} debitos={debitos} />
          <ItemList readOnly={this.props.readOnly} lista={this.props.creditos} legend="Créditos" field='creditos' cols="12 6" />
          <ItemList readOnly={this.props.readOnly} lista={this.props.debitos} legend="Débitos" field='debitos' cols="12 6" showStatus />
        </Row>
        <Row>
          <Grid cols="2">
            <button className={`waves-effect waves-light btn ${this.props.submitClass}`} type="submit">
              {this.props.submitLabel}
            </button>
          </Grid>
          <Grid cols="2">
            <button className="waves-effect waves-light btn amber" type="button" onClick={this.props.init}>
              Cancelar
            </button>
          </Grid>
        </Row>
      </Form>
    );
  }
}

BillingCycleForm = reduxForm({ form: 'billingCycleForm', destroyOnUnmount: false })(BillingCycleForm);

const selector = formValueSelector('billingCycleForm')
const mapStateToProps = (state) => ({
  creditos: selector(state, 'creditos'),
  debitos: selector(state, 'debitos')
})
const mapDispatchToProps = (dispatch) => bindActionCreators({ init }, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(BillingCycleForm);
