import React from 'react'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom'

import Main from './pages/Main'
import Repository from './pages/Repository'

function Routes() {
  return (
    <Router>
      <Switch>
        <Route path="/" exact>
          <Main />
        </Route>

        <Route path="/repository/:name">
          <Repository />
        </Route>
      </Switch>
    </Router>
  )
}

export default Routes
