
db-migrate:
	@echo "Migrating database..."
	@dotnet ef migrations add $(name)
	@echo "Done."

db-update:
	@echo "Updating database..."
	@dotnet ef database update
	@echo "Done."

db-drop:
	@echo "Dropping database..."
	@dotnet ef database drop
	@echo "Done."


db-reset: db-drop db-update

restore:
	@echo "Restoring packages and tools..."
	@dotnet tool restore
	@dotnet restore
	@echo "Done."

dev: restore
	@echo "Running development server..."
	@dotnet watch run

docker:
	@docker compose up --build --no-recreate --detach
