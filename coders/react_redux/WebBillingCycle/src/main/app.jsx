import React from 'react';

import {
  BrowserRouter as Router,
  Redirect,
  Route,
  Switch
} from 'react-router-dom';

import Menu from '../common/template/menu';
import Footer from '../common/template/footer';
import Messages from '../common/msg/messages';

import Dashboard from '../dashboard/dashboard';
import BillingCycle from '../billingCycle/billingCycles';

const App = (props) => (
  <Router>
    <div className="main">
      <Menu />
      <main>
        <Switch>
          <Route exact path="/" component={Dashboard} />
          <Route path="/billingCycles" component={BillingCycle} />
          <Redirect path="*" to="/" />
        </Switch>
      </main>
      <Footer />
      <Messages />
    </div>
  </Router>
);

export default App;
