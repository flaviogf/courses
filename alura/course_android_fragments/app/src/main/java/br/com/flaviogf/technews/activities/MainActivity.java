package br.com.flaviogf.technews.activities;

import android.content.res.Configuration;
import android.os.Bundle;

import androidx.annotation.IdRes;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import br.com.flaviogf.technews.R;
import br.com.flaviogf.technews.fragments.NewsFragment;
import br.com.flaviogf.technews.fragments.NewsListFragment;
import br.com.flaviogf.technews.models.News;

public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("Tech News");

        if (savedInstanceState == null) {
            setFragment(newsListFragment(), R.id.main_activity_news_list_container, "@news-list", false, null);
            return;
        }

        FragmentManager fragmentManager = getSupportFragmentManager();

        Fragment fragment = fragmentManager.findFragmentByTag("@news");

        if (fragment == null) {
            return;
        }

        removeFragment(fragment);

        if (isPortraitOrientation()) {
            Bundle bundle = fragment.getArguments();
            setFragment(newsFragment(), R.id.main_activity_news_list_container, "@news", true, bundle);
            return;
        }

        Bundle bundle = fragment.getArguments();
        setFragment(newsListFragment(), R.id.main_activity_news_list_container, "@news-list", false, null);
        setFragment(newsFragment(), R.id.main_activity_news_container, "@news", false, bundle);
    }

    @Override
    public void onAttachFragment(@NonNull Fragment fragment) {
        super.onAttachFragment(fragment);

        MainActivityListener mainActivityListener = getMainActivityListener();

        if (fragment instanceof NewsListFragment) {
            NewsListFragment newsListFragment = (NewsListFragment) fragment;

            newsListFragment.setOnClickNewsListener(mainActivityListener);

            newsListFragment.setOnFloatingActionButtonClickListener(mainActivityListener);
        }

        if (fragment instanceof NewsFragment) {
            NewsFragment newsFragment = (NewsFragment) fragment;

            newsFragment.setOnOptionsItemDoneSelectedListener(mainActivityListener);
        }
    }

    private NewsListFragment newsListFragment() {
        return new NewsListFragment();
    }

    private NewsFragment newsFragment() {
        return new NewsFragment();
    }

    private void setFragment(Fragment fragment, @IdRes int containerViewId, String tag, Boolean addToBackStack, Bundle bundle) {
        FragmentManager fragmentManager = getSupportFragmentManager();

        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();

        fragmentTransaction.replace(containerViewId, fragment, tag);

        if (addToBackStack) {
            fragmentTransaction.addToBackStack(null);
        }

        fragment.setArguments(bundle);

        fragmentTransaction.commit();
    }

    private void popFragment() {
        FragmentManager fragmentManager = getSupportFragmentManager();

        fragmentManager.popBackStack();
    }

    private void removeFragment(Fragment fragment) {
        FragmentManager fragmentManager = getSupportFragmentManager();

        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();

        fragmentTransaction.remove(fragment);

        fragmentTransaction.commit();

        fragmentManager.popBackStack();
    }

    private MainActivityListener getMainActivityListener() {
        if (isPortraitOrientation()) {
            return new MainActivityPortraitListener(this);
        }

        return new MainActivityLandListener(this);
    }

    private Boolean isPortraitOrientation() {
        int orientation = getResources().getConfiguration().orientation;

        return orientation == Configuration.ORIENTATION_PORTRAIT;
    }

    private interface MainActivityListener extends NewsListFragment.OnClickNewsListener, NewsListFragment.OnFloatingActionButtonClickListener, NewsFragment.OnOptionsItemDoneSelectedListener {
    }

    private static class MainActivityPortraitListener implements MainActivityListener {
        private final MainActivity mainActivity;

        public MainActivityPortraitListener(MainActivity mainActivity) {
            this.mainActivity = mainActivity;
        }

        @Override
        public void onSelect() {
            mainActivity.popFragment();
        }

        @Override
        public void onClick(News news) {
            Bundle bundle = new Bundle();
            bundle.putString("@news-id", news.getId());
            mainActivity.setFragment(mainActivity.newsFragment(), R.id.main_activity_news_list_container, "@news", true, bundle);
        }

        @Override
        public void onClick() {
            mainActivity.setFragment(mainActivity.newsFragment(), R.id.main_activity_news_list_container, "@news", true, null);
        }
    }

    private static class MainActivityLandListener implements MainActivityListener {
        private final MainActivity mainActivity;

        public MainActivityLandListener(MainActivity mainActivity) {
            this.mainActivity = mainActivity;
        }

        @Override
        public void onSelect() {
            mainActivity.setFragment(mainActivity.newsListFragment(), R.id.main_activity_news_list_container, "@news-list", false, null);
            mainActivity.popFragment();
        }

        @Override
        public void onClick(News news) {
            Bundle bundle = new Bundle();
            bundle.putString("@news-id", news.getId());
            mainActivity.setFragment(mainActivity.newsFragment(), R.id.main_activity_news_container, "@news", true, bundle);
        }

        @Override
        public void onClick() {
            mainActivity.setFragment(mainActivity.newsFragment(), R.id.main_activity_news_container, "@news", true, null);
        }
    }
}
