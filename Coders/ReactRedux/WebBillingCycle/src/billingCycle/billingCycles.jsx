import React from 'react';

import { connect } from 'react-redux';

import { bindActionCreators } from 'redux';

import { init, create, update, remove } from './billingCyclesActions';

import ContentHeader from '../common/template/contentHeader';
import Content from '../common/template/content';
import Tabs from '../common/tabs/tabs';
import TabsHeader from '../common/tabs/tabsHeader';
import TabsContent from '../common/tabs/tabsContent';
import TabHeader from '../common/tabs/tabHeader';
import TabContent from '../common/tabs/tabContent';
import BillingCycleLista from './billingCyclesLista';
import BillingCycleForm from './billingCycleForm';

class BillingCycle extends React.Component {
  componentWillMount() {
    this.props.init()
  }

  render() {
    return (
      <Tabs>
        <TabsHeader>
          <TabHeader target="listar" coluna={3}>
            Listar
          </TabHeader>
          <TabHeader target="incluir" coluna={3}>
            Incluir
          </TabHeader>
          <TabHeader target="alterar" coluna={3}>
            Alterar
          </TabHeader>
          <TabHeader target="excluir" coluna={3}>
            Excluir
          </TabHeader>
        </TabsHeader>

        <TabsContent>
          <TabContent id="listar">
            <BillingCycleLista />
          </TabContent>
          <TabContent id="incluir">
            <BillingCycleForm
              onSubmit={this.props.create}
              submitLabel="Cadastrar"
              submitClass="green"
            />
          </TabContent>
          <TabContent id="alterar">
            <BillingCycleForm
              onSubmit={this.props.update}
              submitLabel="Alterar"
              submitClass="blue"
            />
          </TabContent>
          <TabContent id="excluir">
            <BillingCycleForm
              onSubmit={this.props.remove}
              submitLabel="Excluir"
              submitClass="red"
              readOnly
            />
          </TabContent>
        </TabsContent>
      </Tabs>
    );
  }
}

const mapDispatchToProps = (dispatch) => bindActionCreators({ init, create, update, remove }, dispatch);
export default connect(null, mapDispatchToProps)(BillingCycle);
