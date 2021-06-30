# frozen_string_literal: true

require 'rails_helper'

RSpec.describe ArticlesController, type: :controller do
  let!(:user) do
    create(:user)
  end

  let!(:article) do
    create(:article)
  end

  before do
    get :show, params: { id: article.id }
  end

  it 'assign an article' do
    expect(assigns(:article)).to eq(article)
  end

  describe 'POST #create' do
    let(:params) do
      {
        article: attributes_for(:article).merge(user_id: user.id)
      }
    end

    it 'creates a new article' do
      expect do
        post :create, params: params
      end.to change(Article, :count).by(1)
    end
  end
end
