import React from 'react'

function PurchaseOrderPayType() {
  return (
    <div>
      <label htmlFor="order_po_number">PO #</label>
      <input type="password" name="order[po_number]" id="order_po_number" />
    </div>
  )
}

export default PurchaseOrderPayType
