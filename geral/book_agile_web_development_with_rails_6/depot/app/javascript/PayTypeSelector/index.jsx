import React, { useEffect, useState } from 'react'
import NoPayType from './NoPayType'
import CreditCardPayType from './CreditCardPayType'
import CheckPayType from './CheckPayType'
import PurchaseOrderPayType from './PurchaseOrderPayType'

function PayTypeSelector() {
  const [selectedPayType, setSelectedPayType] = useState('')

  function onPayTypeSelected(event) {
    setSelectedPayType(event.target.value)
  }

  return (
    <div className="field">
      <label htmlFor="order_pay_type">Pay type</label>
      <select onChange={onPayTypeSelected} id="order_pay_type" name="order[pay_type]">
        <option value="">Select a payment method</option>
        <option value="Check">Check</option>
        <option value="Credit card">Credit card</option>
        <option value="Purchase order">Purchase order</option>
      </select>
      <PayTypeCustomComponent selectedPayType={selectedPayType} />
    </div>
  )
}

function PayTypeCustomComponent(props) {
  const components = {
    '': NoPayType,
    'Check': CheckPayType,
    'Credit card': CreditCardPayType,
    'Purchase order': PurchaseOrderPayType,
  }

  const Component = components[props.selectedPayType]

  return <Component />
}

export default PayTypeSelector
