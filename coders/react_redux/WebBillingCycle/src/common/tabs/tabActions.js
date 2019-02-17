export const selectTab = (tabId) => {
  return {
    type: 'TAB_SELECTED',
    payload: tabId
  };
};

export const showTabs = (...tabs) => {
  const tabsToShow = {};
  tabs.forEach((tab) => (tabsToShow[tab] = true));
  return {
    type: 'TABS_TO_SHOW',
    payload: tabsToShow
  };
};
