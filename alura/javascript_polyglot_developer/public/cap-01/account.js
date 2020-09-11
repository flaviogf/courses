class Account {
  constructor({ owner, bank, agency, number }) {
    Object.assign(this, { owner, bank, agency, number });
  }
}

export default Account;
