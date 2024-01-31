# PROJECT_ROOT := '../../..'
# MS_BUILD_PATH := --msbuildprojectextensionspath $(PROJECT_ROOT)/dist/intermediates/csharp/20240124/BaseApi/obj

db-migrate:
	@echo "Migrating database..."
	# @dotnet ef migrations add $(name) $(MS_BUILD_PATH)
	@dotnet ef migrations add $(name)
	@echo "Done."

db-update:
	@echo "Updating database..."
	# @dotnet ef database update $(MS_BUILD_PATH)
	@dotnet ef database update
	@echo "Done."

db-drop:
	@echo "Dropping database..."
	@dotnet ef database drop
	@echo "Done."


db-reset: db-drop db-update

restore:
	@echo "Restoring packages..."
	@dotnet restore
	@echo "Done."

dev: restore
	@echo "Running development server..."
	@dotnet watch run

docker:
	@docker compose up --build --no-recreate --detach
