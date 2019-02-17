import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { getList, showUpdate, showDelete } from './billingCyclesActions';

class BillingCycleList extends React.Component {
  componentWillMount() {
    this.props.getList();
  }

  renderRows() {
    return this.props.lista.map((bc) => (
      <tr key={bc._id}>
        <td>{bc.nome}</td>
        <td>{bc.mes}</td>
        <td>{bc.ano}</td>
        <td>
          <a class="waves-effect waves-light btn amber btn-table" onClick={() => this.props.showUpdate(bc)}>
            <i class="material-icons">create</i>
          </a>
          <a class="waves-effect waves-light btn red btn-table" onClick={() => this.props.showDelete(bc)}>
            <i class="material-icons">delete_forever</i>
          </a>
        </td>
      </tr>
    ));
  }

  render() {
    return (
      <div>
        <table>
          <thead>
            <tr>
              <th>Nome</th>
              <th>Mês</th>
              <th>Ano</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>{this.renderRows()}</tbody>
        </table>
      </div>
    );
  }
}

const mapStateToProps = (state) => ({ lista: state.billingCycle.lista });
const mapDispatchToProps = (dispatch) => bindActionCreators({ getList, showUpdate, showDelete }, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(BillingCycleList);
