import React from 'react'

import { Field, arrayInsert, arrayRemove } from 'redux-form'

import { bindActionCreators } from 'redux'

import { connect } from 'react-redux'

import Grid from '../common/layout/grid'
import Input from '../common/form/input'
import If from '../common/operator/if'

class ItemList extends React.Component {

  add(index, value = {}) {
    if (!this.props.readyOnly) {
      this.props.arrayInsert('billingCycleForm', this.props.field, index, value)
    }
  }

  remove(index) {
    if (!this.props.readyOnly && this.props.lista.length > 1) {
      this.props.arrayRemove('billingCycleForm', this.props.field, index)
    }
  }

  rendeRows() {
    let lista = this.props.lista || []
    return lista.map((item, index) => (
      <tr key={index}>
        <td>
          <Field
            name={`${this.props.field}[${index}].nome`}
            readyOnly={this.props.readyOnly}
            placeholder="Informe o nome"
            component={Input}
          />
        </td>
        <td>
          <Field
            name={`${this.props.field}[${index}].valor`}
            readyOnly={this.props.readyOnly}
            placeholder="Informe o valor"
            component={Input}
          />
        </td>
        <If condicao={this.props.showStatus}>
          <td>
            <Field
              name={`${this.props.field}[${index}].status`}
              readyOnly={this.props.readyOnly}
              placeholder="Informe o status"
              component={Input}
            />
          </td>
        </If>
        <td>
          <a class="waves-effect waves-light btn amber btn-table" onClick={() => this.add(index + 1)}>
            <i class="material-icons">add</i>
          </a>
          <a class="waves-effect waves-light btn red btn-table" onClick={() => this.remove(index)}>
            <i class="material-icons">delete</i>
          </a>
        </td>
      </tr>
    ))
  }

  render() {
    return (
      <Grid cols={this.props.cols}>
        <fieldset>
          <legend>{this.props.legend}</legend>
          <table>
            <thead>
              <tr>
                <th>Nome</th>
                <th>Valor</th>
                <th>Ações</th>
                <If condicao={this.props.showStatus}>
                  <th>Status</th>
                </If>
              </tr>
            </thead>
            <tbody>
              {this.rendeRows()}
            </tbody>
          </table>
        </fieldset>
      </Grid>
    )
  }
}

const mapDispatchToProps = (dispatch) => bindActionCreators({ arrayInsert, arrayRemove }, dispatch)

export default connect(null, mapDispatchToProps)(ItemList)
