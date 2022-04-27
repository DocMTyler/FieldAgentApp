ALTER PROCEDURE [ClearanceAudit](
    @securityClearanceId AS INT,
    @agencyId AS INT
)

-- DECLARE @securityClearanceId INT = 1;
-- DECLARE @agencyId INT = 1;
AS
BEGIN

SELECT
sc.SecurityClearanceId,
ag.AgencyId,
aa.BadgeId,
a.LastName + ' ' + a.FirstName as NameLastFirst,
a.DateOfBirth,
aa.ActivationDate,
aa.DeactivationDate
FROM AgencyAgent aa
    JOIN Agency ag ON ag.AgencyId = aa.AgencyId
    JOIN Agent a ON aa.AgentId = a.AgentId
    JOIN SecurityClearance sc ON aa.SecurityClearanceId = sc.SecurityClearanceId
WHERE sc.SecurityClearanceId = @securityClearanceId
    AND ag.AgencyId = @agencyId

END