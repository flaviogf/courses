import React from 'react';

import { connect } from 'react-redux';

import { bindActionCreators } from 'redux';

import { selectTab } from './tabActions';

import If from '../operator/if';
import Content from '../template/content';
import Row from '../layout/row';
import Grid from '../layout/grid';

class TabContent extends React.Component {
  render() {
    const active = this.props.tab.selected === this.props.id;
    const visible = this.props.tab.visible[this.props.id];
    return active ? (
      <If condicao={visible}>
        <Content>
          <Row>{this.props.children}</Row>
        </Content>
      </If>
    ) : null;
  }
}

const mapStateToProps = (state) => ({
  tab: state.tab
});

export default connect(mapStateToProps)(TabContent);
