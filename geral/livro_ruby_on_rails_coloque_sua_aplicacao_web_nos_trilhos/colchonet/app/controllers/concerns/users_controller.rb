class UsersController < ApplicationController
  def new
    @user = User.new
  end

  def create
    @user = User.new(user_params)

    if @user.save
      SignupMailer.with(user: @user).confirm_email.deliver_later

      redirect_to @user, notice: 'Cadastro criado com sucesso!'
    else
      render action: :new
    end
  end

  def show
    @user = User.find(params[:id])
  end

  def edit
    @user = User.find(params[:id])
  end

  def update
    @user = User.find(params[:id])

    if @user.update(user_params)
      redirect_to @user, notice: 'Cadastro atualizado com sucesso!'
    else
      render action: :edit
    end
  end

  private
  def user_params
    params.require(:user).permit(:full_name, :location, :email, :password, :password_confirmation, :bio)
  end
end
