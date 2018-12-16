import React from 'react';

import { connect } from 'react-redux';

import { bindActionCreators } from 'redux';

import { selectTab } from './tabActions';

import If from '../operator/if';

class TabHeader extends React.Component {
  render() {
    const active = this.props.tab.selected === this.props.target ? true : false;
    const visible = this.props.tab.visible[this.props.target];
    return (
      <If condicao={visible}>
        <li className={`tab col s${this.props.coluna}`}>
          <a
            onClick={() => this.props.selectTab(this.props.target)}
            className={active ? 'white-text active' : 'white-text'}
            href="javascript:;"
          >
            {this.props.children}
          </a>
        </li>
      </If>
    );
  }
}

const mapStateToProps = (state) => ({
  tab: state.tab
});

const mapDispatchToProps = (dispatch) => ({
  selectTab: bindActionCreators(selectTab, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(TabHeader);
