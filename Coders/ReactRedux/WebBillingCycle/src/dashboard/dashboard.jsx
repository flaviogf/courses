import React, { Component } from 'react';

import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { getSumary } from './dashboardActions';

import Content from '../common/template/content';
import ContentHeader from '../common/template/contentHeader';
import ValueBox from '../common/widget/valueBox';
import Row from '../common/layout/row';

class Dashboard extends Component {
  componentDidMount() {
    this.props.getSumary();
  }

  render() {
    const { credito, debito } = this.props.sumary;
    return (
      <Content>
        <ContentHeader titulo="Dashboard" subtitulo="Versão 1.0.0" />
        <Row>
          <ValueBox
            cols="12 4"
            cor="green"
            valor={`R$ ${credito}`}
            label="Valor dos créditos"
            corTexto="white"
          />
          <ValueBox
            cols="12 4"
            cor="red"
            valor={`R$ ${debito}`}
            label="Valor dos débitos"
            corTexto="white"
          />
          <ValueBox
            cols="12 4"
            cor="blue"
            valor={`R$ ${credito - debito}`}
            label="Valor consolidado"
            corTexto="white"
          />
        </Row>
      </Content>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    sumary: state.dashboard.sumary
  };
};

const mapDispatchToProps = (dispatch) => {
  return bindActionCreators(
    {
      getSumary
    },
    dispatch
  );
};

export default connect(mapStateToProps, mapDispatchToProps)(Dashboard);
